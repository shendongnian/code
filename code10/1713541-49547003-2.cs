    public class Class1
    {
        /// <summary>
        /// This is the method in my .Net Standard library
        /// </summary>
        /// <returns></returns>
        public static Stream GetImage()
        {
            var assembly = typeof(Class1).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("ClassLibrary1.Assets.dog.jpg");
            return stream;
        }
    }
    
