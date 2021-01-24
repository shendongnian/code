	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using System.Windows.Forms;
	using System.IO;
	namespace ProvaSalvataggioFile2
	{
		public class OpenFile
		{
			public TextFile OpenTextFile()
			{
				TextFile textFile;
				OpenFileDialog openFileDialog1 = new OpenFileDialog();
				openFileDialog1.CheckPathExists = true;
				openFileDialog1.CheckFileExists = true;
				openFileDialog1.RestoreDirectory = true;
				openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
				openFileDialog1.FilterIndex = 1;
				if (openFileDialog1.ShowDialog() == DialogResult.OK)
				{
					string fileName = openFileDialog1.FileName.ToString();
					string textReadFromFile = File.ReadAllText(openFileDialog1.FileName);
					
					textFile = new TextFile(fileName, textReadFromFile);
				}
				return textFile;
			}
		}
	}
