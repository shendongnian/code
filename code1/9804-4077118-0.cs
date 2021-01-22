        public string Format(string input, object p)
        {
            foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(p))
                input = input.Replace("{" + prop.Name + "}", prop.GetValue(p).ToString());
            return input;
        }
