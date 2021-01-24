        public class CompositeIterator<T>
        {
            private Expression<Func<T, bool>> finalQuery;
            private Expression<Func<T, bool>> higherQuery;
            private GroupOperator? previousOperator;
            private int level = -1;
    
            public Expression<Func<T, bool>> Prepare(PredicateGroup predicateGroup)
            {
                previousOperator = predicateGroup.Operator;
                finalQuery = t => predicateGroup.Operator == GroupOperator.And;
                CallRecursive(predicateGroup);
                return finalQuery;
            }
    
            private void CallRecursive(PredicateGroup predicateGroup)
            {
                var nodes = predicateGroup.Predicates;
                bool isSet = true;
                ++level;
    
                foreach (var n in nodes)
                {
                    if (n is PredicateGroup @group)
                    {                  
                        CallRecursive(@group);
                        --level;
                    }
                    else
                    {
                        var expr = PredicateParser<T>.Parse((IFieldPredicate)n);
    
                        if (level > 0)
                        {
                            if (isSet)
                            {
                                higherQuery = t => predicateGroup.Operator == GroupOperator.And;
                                isSet = false;
                            }
    
                            higherQuery = predicateGroup.Operator == GroupOperator.And
                                        ? higherQuery.And(expr)
                                        : higherQuery.Or(expr);
                        }
                        else
                        {
                            previousOperator = predicateGroup.Operator;
    
                            finalQuery = predicateGroup.Operator == GroupOperator.And
                                        ? finalQuery.And(expr)
                                        : finalQuery.Or(expr);
                        }
                    }
                }
    
                if (higherQuery != null)
                {
                    finalQuery = previousOperator == GroupOperator.And
                                ? finalQuery.And(higherQuery)
                                : finalQuery.Or(higherQuery);
                }
    
                higherQuery = null;
            }
        }
