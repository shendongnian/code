        public static T GetValuesAs<T>(this SqlDataReader Reader, T prototype)
        {
            System.Reflection.ConstructorInfo constructor = prototype.GetType().GetConstructors()[0];
            object[] paramValues = constructor.GetParameters().Select(
                p => { try               { return Reader[p.Name]; }
                       catch (Exception) { return prototype.GetType().GetProperty(p.Name).GetValue(prototype); } }
                ).ToArray();
            return (T)prototype.GetType().GetConstructors()[0].Invoke(paramValues);
        }
