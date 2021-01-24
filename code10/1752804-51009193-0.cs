     public virtual bool IsEnum {
         get
         {
            return IsSubclassOf(RuntimeType.EnumType);
         }
