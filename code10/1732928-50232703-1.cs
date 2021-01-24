    class Profession
    {
        ...
        public override string ToString()
        {
            //return string.Format("{{Id: {0}, Description: {1}}}", Id, Description);
            string values = string.Empty;
            foreach (System.Reflection.PropertyInfo pi in myObject.GetType().GetProperties())
                values += pi.Name + ": " + pi.GetValue(myObject) + ", ";
            return values.Substring(0, Math.Max(0, values.Length - 2));
        }
    }
