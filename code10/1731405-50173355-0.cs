    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.SqlServer.TransactSql.ScriptDom;
    using System.IO;
    public static class ProcParser
    {
        static void Main(string[] args)
        {
    
            var procDef = @"
    alter procedure UP_TestDemo
    as
    update dbo.Models set A = '1', B = '2' from Modules m where m.ID = '0001'
    insert DB.dbo.emplyees( Name ) select Name from Person
    
    Exec dbo.UP_LOG @ModifyDate = '05/04/2018'
    GO
    ";
            var statementTargets = ProcParser.GetStatementTargets(procDef);
    
            foreach(var statementTarget in statementTargets)
            {
                Console.WriteLine(statementTarget);
            }
    
        }
    
        public static List<String> GetStatementTargets(string storedProcedureDefinition)
        {
    
            StringReader reader = new StringReader(storedProcedureDefinition);
    
            //specify parser for appropriate SQL version
            var parser = new TSql140Parser(true);
    
            IList<ParseError> errors;
            TSqlFragment sqlFragment = parser.Parse(reader, out errors);
    
            if (errors.Count > 0)
            {
                throw new Exception("Error parsing stored procedure definition");
            }
    
            SQLVisitor sqlVisitor = new SQLVisitor();
            sqlFragment.Accept(sqlVisitor);
    
            return sqlVisitor.StatementTargets;
    
        }
    
    }
    
    internal class SQLVisitor : TSqlFragmentVisitor
    {
    
        public List<String> StatementTargets = new List<String>();
    
        public override void ExplicitVisit(AlterProcedureStatement node)
        {
            node.AcceptChildren(this);
        }
    
        public override void ExplicitVisit(ExecuteStatement node)
        {
            ExecuteSpecification executeSpec = node.ExecuteSpecification;
            ExecutableProcedureReference executableEntity = (ExecutableProcedureReference)executeSpec.ExecutableEntity;
            var tokenText = getTokenText(executableEntity.ProcedureReference);
            StatementTargets.Add($"Execute SP: {tokenText}");
        }
        public override void ExplicitVisit(UpdateStatement node)
        {
            var tokenText = getTokenText(node.UpdateSpecification.Target);
            StatementTargets.Add($"Update Table: {tokenText}");
        }
        public override void ExplicitVisit(InsertStatement node)
        {
            var tokenText = getTokenText(node.InsertSpecification.Target);
            StatementTargets.Add($"Insert Table: {tokenText}");
        }
        public string getTokenText(TSqlFragment frag)
        {
            var sb = new StringBuilder();
            for(int i = frag.FirstTokenIndex; i <= frag.LastTokenIndex; ++i)
            {
                sb.Append(frag.ScriptTokenStream[i].Text);
            }
            return sb.ToString();
    
        }
    }
