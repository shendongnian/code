    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Text;
    namespace stackoverflow
    {
    class Program
    {
        private static List<String> fileNameList = new List<String>();
        private static List<DateTime> fileDateList = new List<DateTime>();
        private static List<String> filename;
        private static List<DateTime> fileDate;
        
        static void Main(string[] args)
        {
            string sDir = "C:\\Work\\DUke_Tee";
            DirSearch(sDir);
            ListSerialize();
            //ListDeserialize();
            Console.WriteLine("done");
            Console.ReadLine();
        }
        private static List<String> DirSearch(string sDir)
        {
            List<String> files = new List<String>();
            try
            {
                foreach (string f in Directory.GetFiles(sDir))
                {
                    DateTime creation = File.GetCreationTime(f);
                    DateTime modification = File.GetLastWriteTime(f);
                    files.Add(f);
                    fileNameList.Add(f);
                    fileDateList.Add(modification);
                }
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    files.AddRange(DirSearch(d));
                }
            }
            catch (System.Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }
            return files;
        }
        public static void ListSerialize()
        {
            try
            {
                using (Stream stream = File.Open("C:\\Work\\dataName.bin", FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, fileNameList);
                }
                using (Stream stream = File.Open("C:\\Work\\dataDate.bin", FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, fileDateList);
                }
            }
            catch (IOException)
            {
            }
        }
        public static void ListDeserialize()
        {    
            try
            {
                using (Stream stream = File.Open("C:\\Work\\dataName.bin", FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    filename = (List<String>)bin.Deserialize(stream);                   
                }
                using (Stream stream = File.Open("C:\\Work\\dataDate.bin", FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    fileDate = (List<DateTime>)bin.Deserialize(stream);
                }
            }
            catch (IOException)
            {
            }
            for (int i = 0; i < filename.Count; i++)
            {
                File.SetLastWriteTime(filename[i], fileDate[i]);
            }   
        }
    }
    }
