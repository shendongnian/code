public static void BindToEnum(Type enumType, ListControl lc)
        {
            // get the names from the enumeration
            string[] names = Enum.GetNames(enumType);
            // get the values from the enumeration
            Array values = Enum.GetValues(enumType);
            // turn it into a hash table
            Hashtable ht = new Hashtable();
            for (int i = 0; i < names.Length; i++)
                // note the cast to integer here is important
                // otherwise we'll just get the enum string back again
                ht.Add(names[i], (int)values.GetValue(i));
            // return the dictionary to be bound to
            lc.DataSource = ht;
            lc.DataTextField = "Key";
            lc.DataValueField = "Value";
            lc.DataBind();
        }
</pre>
