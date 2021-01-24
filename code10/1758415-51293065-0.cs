    public class ResolvedNamedParameter : Parameter
    {
        public override Boolean CanSupplyValue(ParameterInfo pi, 
                                               IComponentContext context, 
                                               out Func<Object> valueProvider)
        {
            if (pi.ParameterType.IsValueType 
                && context.IsRegisteredWithName(pi.Name, pi.ParameterType))
            {
                valueProvider = () => context.ResolveNamed(pi.Name, pi.ParameterType);
                return true;
            }
            else
            {
                valueProvider = null;
                return false;
            }
        }
    }
