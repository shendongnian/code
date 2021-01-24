        public class MyData
        {
            public string Datos { get; set; }
            public string Linea { get; set; }
            public string Grupo { get; set; }
        }
        public static List<MyData> myFunction(string parametro)
        {
            List<MyData> result = new List<MyData>();
            var data = parametro.Split(Convert.ToChar("|"));
            foreach (var check in data)
            {
                MyData temp = new MyData();
                var line = check.Split(',');
                temp.Datos = line[0];
                temp.Linea = line[1];
                temp.Grupo = check;
                result.Add(temp);
            }
            return result;
        }
        static void Main(string[] args)
        {
            var t = myFunction("0,-1|1,-1|2,-1|3,-1|4,-1|5,-1|6,-1|7,-1|8,-1");
        } 
