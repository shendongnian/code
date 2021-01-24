    public class Response 
    {
        public int Success { get; set; }
        public Dictionary<int, Persona> Persona { get; set; }
    }
    
    public class Persona
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
    }
