        public class RootObject
        {
            public Result[] result { get; set; }
        }
        public class Result
        {
            public Encabezado encabezado { get; set; }
            public Respuesta respuesta { get; set; }
        }
        public class Encabezado
        {
            public string resultado { get; set; }
            public string imensaje { get; set; }
            public string mensaje { get; set; }
            public string tiempo { get; set; }
        }
        public class Respuesta
        {
            public Datos datos { get; set; }
        }
        public class Datos
        {
            public string crear { get; set; }
        }
