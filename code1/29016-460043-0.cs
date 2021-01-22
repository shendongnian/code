    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    
    namespace Reposes
    {
    	class ReposeFile
    	{
    		string m_name;
    
    		public string Name
    		{
    			get { return m_name; }
    		}
    
    		public ReposeFile(string name)
    		{
    			m_name = name;
    		}
    	}
    
    	interface IRepose
    	{
    		void RetriveFiles();
    		ReposeFile[] Files { get; }
    	}
    
    	class FileSystemRepose : IRepose
    	{
    		string m_path = null;
    		List<ReposeFile> m_files = new List<ReposeFile>();
    
    		public FileSystemRepose(string path)
    		{
    			m_path = path;
    		}
    
    		#region IRepose Members
    
    		public void RetriveFiles()
    		{
    			string[] files = Directory.GetFiles(m_path);
    			foreach (string file in files)
    			{
    				m_files.Add(new ReposeFile(file));
    			}
    		}
    
    		public ReposeFile[] Files
    		{
    			get { return m_files.ToArray(); }
    		}
    
    		#endregion
    	}
    
    	class AssemblyRepose : IRepose
    	{
    		string m_assembly = null;
    		List<ReposeFile> m_files = new List<ReposeFile>();
    
    		public AssemblyRepose(string assembly)
    		{
    			m_assembly = assembly;
    		}
    
    		#region IRepose Members
    
    		public void RetriveFiles()
    		{
    			m_files.Add(new ReposeFile("Stuff"));
    		}
    
    		public ReposeFile[] Files
    		{
    			get { return m_files.ToArray(); }
    		}
    
    		#endregion
    	}
    
    	class Consumer
    	{
    		static void Main()
    		{
    			List<IRepose> reps = new List<IRepose>();
    			reps.Add(new FileSystemRepose("c:\\")); // would normally be @"c:\" but stackoverflow's syntax highlighter barfed :)
    			reps.Add(new AssemblyRepose("rep.dll"));
    
    			foreach (IRepose rep in reps)
    			{
    				rep.RetriveFiles();
    
    				foreach (ReposeFile file in rep.Files)
    				{
    					Console.WriteLine(file.Name);
    				}
    			}
    
    			Console.ReadKey();
    		}
    	}
    }
