    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using System;
    static class Crypto
    {
        static byte[] Serialize(object o)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf1 = new BinaryFormatter();
            bf1.Serialize(ms, o);
            byte[] buffer = ms.ToArray();
            //string retStr = Convert.ToBase64String(buffer);
            return buffer;
        }
    
        public static object Deserialize(byte[] TheByteArray)
        {
            //byte[] TheByteArray = Convert.FromBase64String(ParamStr);
            MemoryStream ms = new MemoryStream(TheByteArray);
            BinaryFormatter bf1 = new BinaryFormatter();
            ms.Position = 0;
            return bf1.Deserialize(ms);
        }
        [Serializable]
        class Student
        {
            public string UserName { get; set; }
            public string Password { get; set; }
            public int[] LessonIds { get; set; }
            public string[] LessonNames { get; set; }
            public int Id { get; set; }
        }
        static void Main()
        {
            Student obj = new Student();
            obj.UserName = "Admin";
            obj.Password = "Password";
            obj.LessonIds = new int[] { 1, 2, 3, 4, 5 };
            obj.LessonNames = new string[] { "Spanish", "Maths" };
            obj.Id = 43;
            byte[] retByteArray = Crypto.Serialize(obj);
    
            Student objNew = (Student)Crypto.Deserialize(retByteArray);
        }
    }
