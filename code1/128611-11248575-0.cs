    using System;
    using System.Data.SqlTypes;
    using Microsoft.SqlServer.Server;
    using System.Text.RegularExpressions;
    using System.Collections;
    using System.Collections.Generic;
    
    public partial class UserDefinedFunctions {    
      [SqlFunction]
      public static SqlBoolean RegexPatternMatch(string Input, string Pattern) {    
        return Regex.Match(Input, Pattern).Success ? new SqlBoolean(true) : new SqlBoolean(false);
      }
    
      [SqlFunction]
      public static SqlString RegexGroupValue(string Input, string Pattern, int GroupNumber) {
    
        Match m = Regex.Match(Input, Pattern);
        SqlString value = m.Success ? m.Groups[GroupNumber].Value : null;
    
        return value;
      }
    
      [SqlFunction(DataAccess = DataAccessKind.Read, FillRowMethodName = "FillMatches", TableDefinition = "GroupNumber int, MatchText nvarchar(4000)")]
      public static IEnumerable RegexGroupValues(string Input, string Pattern) {
        List<RegexMatch> GroupCollection = new List<RegexMatch>();
    
        Match m = Regex.Match(Input, Pattern);
        if (m.Success) {
          for (int i = 0; i < m.Groups.Count; i++) {
            GroupCollection.Add(new RegexMatch(i, m.Groups[i].Value));
          }
        }
    
        return GroupCollection;
      }
    
      public static void FillMatches(object Group, out SqlInt32 GroupNumber, out SqlString MatchText) {
        RegexMatch rm = (RegexMatch)Group;
        GroupNumber = rm.GroupNumber;
        MatchText = rm.MatchText;
      }
    
      private class RegexMatch {
        public SqlInt32 GroupNumber { get; set; }
        public SqlString MatchText { get; set; }
    
        public RegexMatch(SqlInt32 group, SqlString match) {
          this.GroupNumber = group;
          this.MatchText = match;
        }
      }
    };
