    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    
    namespace Serializing_Files
    {
        [Serializable]
        public class Dog
        {
            public string Name { get; set; }
            public string Breed { get; set; }
            public int Age { get; set; }
            public bool IsFemale { get; set; }
    
            public Dog(string Name, string Breed, int Age, bool IsFemale)
            {
                this.Name = Name;
                this.Breed = Breed;
                this.Age = Age;
                this.IsFemale = IsFemale;
            }
    
            public override string ToString()
            {
                string dogInfo;
    
                dogInfo = "Name: " + this.Name + Environment.NewLine + "Breed: " + this.Breed + Environment.NewLine + "Age: " + this.Age + Environment.NewLine;
                if (this.IsFemale)
                {
                    dogInfo += "Gender: Female";
                }
                else
                {
                    dogInfo += "Gender: Male";
                }
                dogInfo += Environment.NewLine;
    
                return dogInfo;
            }
        }
    
        public static class DogsFile
        {
            public static BinaryFormatter BFormatter { get; set; }
            public static FileStream FStream { get; set; }
            public static void WriteDog(string FileName, Dog[] NewDogs)
            {
                FStream = new FileStream(FileName, FileMode.Create, FileAccess.Write);
                BFormatter = new BinaryFormatter();
                BFormatter.Serialize(FStream, NewDogs);
    
                Console.WriteLine("The following dogs were written to the file:" + Environment.NewLine);
    
                for (int i = 0; i < NewDogs.Length; i++)
                {
                    Console.WriteLine(NewDogs[i].ToString());
                }
    
                Console.WriteLine(Environment.NewLine);
    
                FStream.Close();
            }
    
            public static Dog[] ReadDogs(string FileName)
            {
                FStream = new FileStream(FileName, FileMode.Open, FileAccess.Read);
                BFormatter = new BinaryFormatter();
                var DogArray = (Dog[])BFormatter.Deserialize(FStream);
    
                Console.WriteLine("The file contains the following dogs:"+Environment.NewLine);
    
                for (int i = 0; i < DogArray.Length; i++)
                {
                    Console.WriteLine(DogArray[i].ToString());
                }
    
                FStream.Close();
                return DogArray;
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                string filename = @"C:\Dogfile1.ser";
                Dog[] allDogs = new Dog[3];
    
                allDogs[0] = new Dog("Scruffy", "Maltese", 3, true);
    
                allDogs[1] = new Dog("Butch", "Bulldog", 1, false);
    
                allDogs[2] = new Dog("Balo", "Chow Chow", 1, false);
    
                DogsFile.WriteDog(filename, allDogs);
    
                DogsFile.ReadDogs(filename);
    
                Console.ReadLine();
            }
        }
    }
