    internal class ParamaterLogModifiedUtility
    {
        private  String _methodName;
        private String _paramaterLog;
        private readonly JavaScriptSerializer _serializer;
        private readonly Dictionary<String, Type> _methodParamaters;
        private readonly List<Tuple<String, Type, object>>_providedParametars;
        public ParamaterLogModifiedUtility(params Expression<Func<object>>[] providedParameters)
        {
            try
            {
                _serializer = new JavaScriptSerializer();
                var currentMethod = new StackTrace().GetFrame(1).GetMethod();
                /*Set class and current method info*/
                _methodName = String.Format("Class = {0}, Method = {1}", currentMethod.DeclaringType.FullName, currentMethod.Name);
                /*Get current methods paramaters*/
                _methodParamaters = new Dictionary<string, Type>();
                (from aParamater in currentMethod.GetParameters()
                 select new { Name = aParamater.Name, DataType = aParamater.ParameterType })
                 .ToList()
                 .ForEach(obj => _methodParamaters.Add(obj.Name, obj.DataType));
                /*Get provided methods paramaters*/
                _providedParametars = new List<Tuple<string, Type, object>>();
                foreach (var aExpression in providedParameters)
                {
                    Expression bodyType = aExpression.Body;
                    if (bodyType is MemberExpression)
                    {
                        AddProvidedParamaterDetail((MemberExpression)aExpression.Body);
                    }
                    else if (bodyType is UnaryExpression)
                    {
                        UnaryExpression unaryExpression = (UnaryExpression)aExpression.Body;
                        AddProvidedParamaterDetail((MemberExpression)unaryExpression.Operand);
                    }
                    else
                    {
                        throw new Exception("Expression type unknown.");
                    }
                }
                /*Process log for all method parameters*/
                ProcessLog();
            }
            catch (Exception exception)
            {
                throw new Exception("Error in paramater log processing.", exception);
            }
        }
        private void ProcessLog()
        {
            try
            {
                foreach (var aMethodParamater in _methodParamaters)
                {
                    var aParameter =
                        _providedParametars.Where(
                            obj => obj.Item1.Equals(aMethodParamater.Key) && obj.Item2 == aMethodParamater.Value).Single();
                    _paramaterLog += String.Format(@" ""{0}"":{1},", aParameter.Item1, _serializer.Serialize(aParameter.Item3));
                }
                _paramaterLog = (_paramaterLog != null) ? _paramaterLog.Trim(' ', ',') : string.Empty;
            }
            catch (Exception exception)
            {
                throw new Exception("MathodParamater is not found in providedParameters.");
            }
        }
        private void AddProvidedParamaterDetail(MemberExpression memberExpression)
        {
            ConstantExpression constantExpression = (ConstantExpression) memberExpression.Expression;
            var name = memberExpression.Member.Name;
            var value = ((FieldInfo) memberExpression.Member).GetValue(constantExpression.Value);
            var type = value.GetType();
            _providedParametars.Add(new Tuple<string, Type, object>(name, type, value));
        }
        public String GetLog()
        {
            return String.Format("{0}({1})", _methodName, _paramaterLog);
        }
    }
