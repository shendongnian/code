    public class ObjectToSerialize
    {
        public encabezado encabezado { get; set; }
        public datosprincipales datosprincipales { get; set; }
        public listamovimientos listamovimientos { get; set; }
    }
    string json = JsonConvert.SerializeObject(new ObjectToSerialize());
			
