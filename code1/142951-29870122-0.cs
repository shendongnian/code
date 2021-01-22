            List<IComparable> main = new List<IComparable>() { "str", "řetězec" };
            IComparable[] main0 = new IComparable[] { "str", "řetězec" };
            IEnumerable collection = (IEnumerable)main;
            //IEnumerable collection = (IEnumerable)main0;
            string str = (string) main[0];
            if (collection.GetType().IsArray)
            {
                if (collection.GetType().GetElementType().IsAssignableFrom(str.GetType()))
                {
                    MessageBox.Show("Type \"" + str.GetType() + "\" is ok!");
                }
                else
                {
                    MessageBox.Show("Bad Collection Member Type");
                }
            }
            else
            {
                if (collection.GetType().GenericTypeArguments[0].IsAssignableFrom(str.GetType()))
                {
                    MessageBox.Show("Type \"" + str.GetType() + "\" is ok!");
                }
                else
                {
                    MessageBox.Show("Bad Collection Member Type");
                }
            }
