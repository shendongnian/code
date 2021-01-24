        public static CastedAction<T> MakeSetter(FieldInfo field)
        {
            if (field.FieldType.IsInterfaceEx() == true && field.FieldType.IsValueTypeEx() == false)
            {
                ParameterExpression targetExp = Expression.Parameter(typeof(T).MakeByRefType(), "target");
                ParameterExpression valueExp = Expression.Parameter(typeof(object), "value");
                MemberExpression fieldExp = Expression.Field(targetExp, field);
                UnaryExpression convertedExp = Expression.TypeAs(valueExp, field.FieldType);
                BinaryExpression assignExp = Expression.Assign(fieldExp, convertedExp);
                var setter = Expression.Lambda<ActionRef<T, object>>(assignExp, targetExp, valueExp).Compile();
                return new CastedAction<T>(setter); 
            }
            throw new ArgumentException("<color=orange>Svelto.ECS</color> unsupported field (must be an interface and a class)");
        }
    public delegate void ActionRef<T, O>(ref T target, O value);
    
    public class CastedAction<T>  
    {
        readonly ActionRef<T, object> setter;
        public CastedAction(Delegate setter)
        {
            this.setter = (ActionRef<T, object>)setter;
        }
        public CastedAction(ActionRef<T, object> setter)
        {
            this.setter = setter;
        }
        public void Call(ref T target, object value)
        {
            setter(ref target, value);
        }
    }
