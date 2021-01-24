        public static HashSet<Drow> GetRows()
        {
            HashSet<Drow> Drows = new HashSet<Drow>();
            SqlCommand cmd = new SqlCommand();
            SqlDataReader rdr = cmd.ExecuteReader();
            int a;
            int b;
            double c;
            string d;
            while(rdr.Read())
            {
                a = rdr.GetInt32(0);
                b = rdr.GetInt32(1);
                c = rdr.GetDouble(2);
                d = rdr.GetString(3);
                Drow drow = new Drow(a, b, c, d);
                Drows.Add(drow); //it just will not add if it is a duplicat
            }
            return Drows;
        }
    }
    class Drow : object
    {
        int ai;
        int bi;
        public string A { get; }
        public string B { get; }
        public double C { get; }
        public string D { get; }
        public Drow(int a, int b, double c, string d)
        {
            ai = a;
            bi = b;
            A = a.ToString();
            B = b.ToString();
            C = c;
            D = d;
        }
        public override bool Equals(Object obj)
        {
            // Check for null values and compare run-time types.
            if (obj == null || GetType() != obj.GetType())
                return false;
            Drow r = (Drow)obj;
            return (A == r.A) && (B == r.B);
        }
        public override int GetHashCode()
        {
            return ai ^ bi;
        }
    }
