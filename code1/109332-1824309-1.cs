    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    public static class Dumper
    {
        public class Dump
        {
            public Dump(bool spacesInsteadOfTab)
            {
                _spacesIndeadOfTab = spacesInsteadOfTab;
            }
            private readonly StringBuilder _sb = new StringBuilder();
            public string Result
            {
                get
                {
                    return _sb.ToString();
                }
            }
            private readonly bool _spacesIndeadOfTab;
            private int _currentIndent;
            public int CurrentIndent
            {
                get
                {
                    return _currentIndent;
                }
                set
                {
                    _currentIndent = value > 0 ? value : 0;
                }
            }
            public void IncrementIndent()
            {
                CurrentIndent += 1;
            }
            public void DecrementIndent()
            {
                CurrentIndent -= 1;
            }
            private void AppendIndent()
            {
                if (_spacesIndeadOfTab)
                    _sb.Append(' ', _currentIndent * 4);
                else
                    _sb.Append('\t', _currentIndent);
            }
            public void Log(string logValue)
            {
                AppendIndent();
                _sb.AppendLine(logValue);
            }
            public void Log(string logValue, params object[] args)
            {
                AppendIndent();
                _sb.AppendFormat(logValue, args);
                _sb.AppendLine();
            }
        }
        public static Dump TakeDump(object objectToDump, int maxDepth)
        {
            Dump result = new Dump(false);
            int currentDepth = 0;
            TakeDump(ref result, ref currentDepth, maxDepth, objectToDump);
            return result;
        }
        private static void TakeDump(ref Dump result, ref int currentDepth, int maxDepth, object objectToDump)
        {
            currentDepth++;
            if (currentDepth > maxDepth)
            {
                result.IncrementIndent();
                result.Log("MaxDepth ({0}) Reached.", maxDepth);
                result.DecrementIndent();
                return;
            }
            var objectType = objectToDump.GetType();
            result.Log("--> {0}", objectType.FullName);
            result.IncrementIndent();
            var fields = objectType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            if (fields.Count() == 0)
                result.Log("No fields");
            foreach (var fieldInfo in fields)
            {
                var fieldValue = fieldInfo.GetValue(objectToDump);
                if (fieldValue == null)
                    result.Log("{0} is null", fieldValueType.FullName, fieldInfo.Name);
                var fieldValueType = fieldValue.GetType();
                if (fieldValueType.IsValueType)
                    result.Log("{2} as {0} (ToString: {1})", fieldValueType.FullName, fieldValue.ToString(), fieldInfo.Name);
                else
                    TakeDump(ref result, ref currentDepth, maxDepth, fieldValue);
            }
            result.DecrementIndent();
        }
    }
