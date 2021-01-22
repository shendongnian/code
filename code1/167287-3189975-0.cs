    public class Ol11ImportStrategy 
    	{
    		const string registryPath = @"HKEY_CURRENT_USER\Software\Microsoft\Windows NT\CurrentVersion\Windows Messaging Subsystem\Profiles\Outlook\9375CFF0413111d3B88A00104B2A6676\{0}\{1}";
    		const string constAccountName = "Account Name";
    		const string constEmail = "Email";
    		const string constSMTPServer = "SMTP Server";
    		const string constName = "Display Name";
    		const string constIMAPServer = "IMAP Server";
    		const string constPOP3Server = "POP3 Server";
    		const string constValueClsid = "clsid";
    		const string constContentsAccountClsid_POP3 = "{ED475411-B0D6-11D2-8C3B-00104B2A6676}";
    		const string constContentsAccountClsid_IMAP = "{ED475412-B0D6-11D2-8C3B-00104B2A6676}";
    
    		public IEnumerable<AccountEntity> GetAccountsInFriendlyFormat()
    		{
    			List<AccountEntity> accounts = new List<AccountEntity>();
    
    			using (dynamic WShell = AutomationFactory.CreateObject("WScript.Shell"))
    			{
    				for (int i = 1; i < 1000; i++)
    				{
    					try
    					{
    						string classId = WShell.RegRead(String.Format(registryPath, i.ToString().PadLeft(8, '0'), constValueClsid));
    
    						if (StringComparer.InvariantCultureIgnoreCase.Compare(classId, constContentsAccountClsid_POP3) == 0)
    						{
    							accounts.Add(new AccountEntity
    							{
    								FriendlyName = GetRegisterElementValue(WShell, i.ToString(), constAccountName),
    								IncomingMailServer = GetRegisterElementValue(WShell, i.ToString(), constPOP3Server),
    								Email = GetRegisterElementValue(WShell, i.ToString(), constEmail),
    								UserName = GetRegisterElementValue(WShell, i.ToString(), constName)
    							});
    							continue;
    						}
    
    						if (StringComparer.InvariantCultureIgnoreCase.Compare(classId, constContentsAccountClsid_IMAP) == 0)
    						{
    							accounts.Add(new AccountEntity
    							{
    								FriendlyName = GetRegisterElementValue(WShell, i.ToString(), constAccountName),
    								IncomingMailServer = GetRegisterElementValue(WShell, i.ToString(), constIMAPServer),
    								Email = GetRegisterElementValue(WShell, i.ToString(), constEmail),
    								UserName = GetRegisterElementValue(WShell, i.ToString(), constName)
    							});
    							continue;
    						}
    
    						//it isn't POP3 either IMAP
    					}
    					catch (FileNotFoundException e)
    					{
    						//classId isn't found - we can break iterations because we already iterate through all elements
    						break;
    					}
    					catch (Exception e)
    					{
    						MessageBox.Show("Unknown exception");
    					}
    				}
    			}
    
    			return accounts;
    		}
    
    		private string GetRegisterElementValue(object scriptShell, string elementNumber, string elementName)
    		{
    			dynamic shell = scriptShell;
    			string currentElement = elementNumber.PadLeft(8, '0');
    
    			object[] currentElementData = shell.RegRead(String.Format(registryPath, currentElement, elementName));
    
    			byte[] dataBytes = currentElementData.Cast<byte>().ToArray();
    			return Encoding.Unicode.GetString(dataBytes, 0, dataBytes.Count()).Trim('\0');
    		}
    	}
	public class AccountEntity
	{
		public string FriendlyName { get; set; }
		public string UserName { get; set; }
		public string Email { get; set; }
		public string AccountType { get; set; }
		public string IncomingMailServer { get; set; }
	}
