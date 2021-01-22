    public static class ActionSwitch
    {
      public class SwitchOn<TEnum>
      {
        private TEnum Value { get; set; }
        internal SwitchOn(TEnum value)
        {
          Value = value;
        }
        public class Call<TTarget>{
          private TEnum Value { get; set; }
          private TTarget Target { get; set; }
          internal Call(TEnum value, TTarget target)
          {
            Value = value;
            Target = target;
            Invoke();
          }
          internal void Invoke(){
              DynamicSwitch<TTarget, TEnum, Action<TTarget>>.Resolve(Value)(Target);
          }
        }
        public Call<TTarget> On<TTarget>(TTarget target)
        {
          return new Call<TTarget>(Value, target);
        }
      }
      public static SwitchOn<TEnum> Switch<TEnum>(TEnum onValue)
      {
        return new SwitchOn<TEnum>(onValue);
      }
    }
