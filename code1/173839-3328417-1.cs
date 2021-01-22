    using Microsoft.Data.Schema.ScriptDom;
    using Microsoft.Data.Schema.ScriptDom.Sql;
    
    public class SqlParser
    {
            public List<string> Parse(string sql)
            {
                TSql100Parser parser = new TSql100Parser(false);
                IScriptFragment fragment;
                IList<ParseError> errors;
                fragment = parser.Parse(new StringReader(sql), out errors);
                if (errors != null && errors.Count > 0)
                {
                    List<string> errorList = new List<string>();
                    foreach (var error in errors)
                    {
                        errorList.Add(error.Message);
                    }
                    return errorList;
                }
                return null;
            }
    }
