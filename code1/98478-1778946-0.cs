    using System;
    using System.Collections.Specialized;
    using System.Configuration;
    using System.Xml;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using System.Reflection;
    using System.Text;
    using MyApp.Forms;
    using MyApp.Entities;
    
    namespace MyApp.Properties
    {
    	public sealed partial class Settings
    	{
    		private static readonly Version CurrentVersion = Assembly.GetExecutingAssembly().GetName().Version;
    
    		private Settings()
    		{
    			InitCollections();  // ignore
    		}
            
    		public override void Upgrade()
    		{
    			UpgradeFromPreviousVersion();
    			BadDataFiles = new StringCollection();  // ignore
    			UpgradePerformed = true; // this is a boolean value in the settings file that is initialized to false to indicate that settings file is brand new and requires upgrading
    			InitCollections();  // ignore
    			Save();
    		}
    
    		// ignore
    		private void InitCollections()
    		{
    			if (BadDataFiles == null)
    				BadDataFiles = new StringCollection();
    
    			if (UploadedGames == null)
    				UploadedGames = new StringDictionary();
    
    			if (SavedSearches == null)
    				SavedSearches = SavedSearchesCollection.Default;
    		}
    
    		private void UpgradeFromPreviousVersion()
    		{
    			try
    			{
    				// This works for both ClickOnce and non-ClickOnce applications, whereas
    				// ApplicationDeployment.CurrentDeployment.DataDirectory only works for ClickOnce applications
    				DirectoryInfo currentSettingsDir = new FileInfo(ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal).FilePath).Directory;
    
    				if (currentSettingsDir == null)
    					throw new Exception("Failed to determine the location of the settings file.");
    
    				if (!currentSettingsDir.Exists)
    					currentSettingsDir.Create();
    
    				// LINQ to Objects for .NET 2.0 courtesy of LINQBridge (linqbridge.googlecode.com)
    				var previousSettings = (from dir in currentSettingsDir.Parent.GetDirectories()
    				                        let dirVer = new { Dir = dir, Ver = new Version(dir.Name) }
    				                        where dirVer.Ver < CurrentVersion
    				                        orderby dirVer.Ver descending
    				                        select dirVer).FirstOrDefault();
    
    				if (previousSettings == null)
    					return;
    
    				XmlElement userSettings = ReadUserSettings(previousSettings.Dir.GetFiles("user.config").Single().FullName);
    				userSettings = SettingsUpgrader.Upgrade(userSettings, previousSettings.Ver);
    				WriteUserSettings(userSettings, currentSettingsDir.FullName + @"\user.config", true);
    
    				Reload();
    			}
    			catch (Exception ex)
    			{
    				MessageBoxes.Alert(MessageBoxIcon.Error, "There was an error upgrading the the user settings from the previous version. The user settings will be reset.\n\n" + ex.Message);
    				Default.Reset();
    			}
    		}
    
    		private static XmlElement ReadUserSettings(string configFile)
    		{
    			// PreserveWhitespace required for unencrypted files due to https://connect.microsoft.com/VisualStudio/feedback/ViewFeedback.aspx?FeedbackID=352591
    			var doc = new XmlDocument { PreserveWhitespace = true };
    			doc.Load(configFile);
    			XmlNode settingsNode = doc.SelectSingleNode("configuration/userSettings/MyApp.Properties.Settings");
    			XmlNode encryptedDataNode = settingsNode["EncryptedData"];
    			if (encryptedDataNode != null)
    			{
    				var provider = new RsaProtectedConfigurationProvider();
    				provider.Initialize("userSettings", new NameValueCollection());
    				return (XmlElement)provider.Decrypt(encryptedDataNode);
    			}
    			else
    			{
    				return (XmlElement)settingsNode;
    			}
    		}
    
    		private static void WriteUserSettings(XmlElement settingsNode, string configFile, bool encrypt)
    		{
    			XmlDocument doc;
    			XmlNode MyAppSettings;
    
    			if (encrypt)
    			{
    				var provider = new RsaProtectedConfigurationProvider();
    				provider.Initialize("userSettings", new NameValueCollection());
    				XmlNode encryptedSettings = provider.Encrypt(settingsNode);
    				doc = encryptedSettings.OwnerDocument;
    				MyAppSettings = doc.CreateElement("MyApp.Properties.Settings").AppendNewAttribute("configProtectionProvider", provider.GetType().Name);
    				MyAppSettings.AppendChild(encryptedSettings);
    			}
    			else
    			{
    				doc = settingsNode.OwnerDocument;
    				MyAppSettings = settingsNode;
    			}
    
    			doc.RemoveAll();
    			doc.AppendNewElement("configuration")
    				.AppendNewElement("userSettings")
    				.AppendChild(MyAppSettings);
    			
    			using (var writer = new XmlTextWriter(configFile, Encoding.UTF8) { Formatting = Formatting.Indented, Indentation = 4 })
    				doc.Save(writer);
    		}
    
    		private static class SettingsUpgrader
    		{
    			private static readonly Version MinimumVersion = new Version(0, 2, 1, 0);
    
    			public static XmlElement Upgrade(XmlElement userSettings, Version oldSettingsVersion)
    			{
    				if (oldSettingsVersion < MinimumVersion)
    					throw new Exception("The minimum required version for upgrade is " + MinimumVersion);
    
    				var upgradeMethods = from method in typeof(SettingsUpgrader).GetMethods(BindingFlags.Static | BindingFlags.NonPublic)
    				                     where method.Name.StartsWith("UpgradeFrom_")
    									 let methodVer = new { Version = new Version(method.Name.Substring(12).Replace('_', '.')), Method = method }
    									 where methodVer.Version >= oldSettingsVersion && methodVer.Version < CurrentVersion
    									 orderby methodVer.Version ascending 
    				                     select methodVer;
    
    				foreach (var methodVer in upgradeMethods)
    				{
    					try
    					{
    						methodVer.Method.Invoke(null, new object[] { userSettings });
    					}
    					catch (TargetInvocationException ex)
    					{
    						throw new Exception(string.Format("Failed to upgrade user setting from version {0}: {1}",
    						                                  methodVer.Version, ex.InnerException.Message), ex.InnerException);
    					}
    				}
    
    				return userSettings;
    			}
    
    			private static void UpgradeFrom_0_2_1_0(XmlElement userSettings)
    			{
    				// ignore method body - put your own upgrade code here
    
    				var savedSearches = userSettings.SelectNodes("//SavedSearch");
    
    				foreach (XmlElement savedSearch in savedSearches)
    				{
    					string xml = savedSearch.InnerXml;
    					xml = xml.Replace("IRuleOfGame", "RuleOfGame");
    					xml = xml.Replace("Field>", "FieldName>");
    					xml = xml.Replace("Type>", "Comparison>");
    					savedSearch.InnerXml = xml;
    
    
    					if (savedSearch["Name"].GetTextValue() == "Tournament")
    						savedSearch.AppendNewElement("ShowTournamentColumn", "true");
    					else
    						savedSearch.AppendNewElement("ShowTournamentColumn", "false");
    				}
    			}
    		}
    	}
    }
