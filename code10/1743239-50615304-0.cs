    public class HierarchySorting<StringField> : BqlFormulaEvaluator<StringField>, IBqlOperand
            where StringField : IBqlField
    {
        public override object Evaluate(PXCache cache, object item, 
                                        Dictionary<Type, object> pars)
        {
            PXFieldState fState = cache.GetStateExt<StringField>(item) as PXFieldState;
            return GetSortOrderValueExt(Convert.ToString(fState.Value));
        }
        public string GetSortOrderValueExt(string taskCD)
        {
            return Regex.Replace(taskCD, "[0-9]+", MatchReplacer => MatchReplacer.Value.PadLeft(10, '0'));
        }
    }
