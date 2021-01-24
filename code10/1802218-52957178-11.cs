    [ImmutableObject(true)]
    public struct MyModel : IModel, IEquatable<MyModel>
    {
        ...
        #region Equality Comparison
        public override bool Equals(object obj)
        {
            if(obj is MyModel model)
            {
                return Equals(model);
            }
            return false;
        }
        public bool Equals(MyModel other)
        {
            return A==other.A&&
                   B==other.B;
        }
        public override int GetHashCode()
        {
            var hashCode = -1817952719;
            hashCode=hashCode*-1521134295+A.GetHashCode();
            hashCode=hashCode*-1521134295+B.GetHashCode();
            return hashCode;
        }
        public static bool operator ==(MyModel model1, MyModel model2)
        {
            return model1.Equals(model2);
        }
        public static bool operator !=(MyModel model1, MyModel model2)
        {
            return !(model1==model2);
        }
        #endregion
    ...
    }
