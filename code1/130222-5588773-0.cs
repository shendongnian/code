    using System;
    using System.Text.RegularExpressions;
    using Microsoft.StyleCop;
    using Microsoft.StyleCop.CSharp;
    
    namespace CustomRules.StyleCop.CSharp
    {
      [SourceAnalyzer(typeof(CsParser))]
      public class SpacingRules : SourceAnalyzer
      {
        public SpacingRules()
        {
        }
    
        public override void AnalyzeDocument(CodeDocument document)
        {
          Param.RequireNotNull(document, "document");
    
          CsDocument csdocument = (CsDocument)document;
          if (csdocument.RootElement != null && !csdocument.RootElement.Generated)
          {
            this.CheckSpacing(csdocument.Tokens);
          }
        }
    
        private void CheckSpacing(MasterList<CsToken> tokens)
        {
          Param.AssertNotNull(tokens, "tokens");
    
          foreach (var token in tokens)
          {
            if (this.Cancel)
            {
              break;
            }
    
            if (token.Generated)
            {
              continue;
            }
    
            switch (token.CsTokenType)
            {
              case CsTokenType.WhiteSpace:
                this.CheckWhitespace(token as Whitespace);
                break;
    
              case CsTokenType.XmlHeader:
                XmlHeader header = (XmlHeader)token;
                foreach (var xmlChild in header.ChildTokens)
                {
                  this.CheckTabsInComment(xmlChild);
                }
                break;
    
              case CsTokenType.SingleLineComment:
              case CsTokenType.MultiLineComment:
                this.CheckTabsInComment(token);
                break;
            }
    
            switch (token.CsTokenClass)
            {
              case CsTokenClass.ConstructorConstraint:
                this.CheckSpacing(((ConstructorConstraint)token).ChildTokens);
                break;
    
              case CsTokenClass.GenericType:
                this.CheckGenericSpacing((GenericType)token);
                this.CheckSpacing(((TypeToken)token).ChildTokens);
                break;
    
              case CsTokenClass.Type:
                this.CheckSpacing(((TypeToken)token).ChildTokens);
                break;
            }
          }
        }
    
        private void CheckGenericSpacing(GenericType generic)
        {
          Param.AssertNotNull(generic, "generic");
          if (generic.ChildTokens.Count == 0)
          {
            return;
          }
    
          foreach (var token in generic.ChildTokens)
          {
            if (this.Cancel)
            {
              break;
            }
    
            if (token.CsTokenClass == CsTokenClass.GenericType)
            {
              this.CheckGenericSpacing(token as GenericType);
            }
    
            if (!token.Generated && token.CsTokenType == CsTokenType.WhiteSpace)
            {
              this.CheckWhitespace(token as Whitespace);
            }
          }
        }
    
        private void CheckWhitespace(Whitespace whitespace)
        {
          Param.AssertNotNull(whitespace, "whitespace");
    
          if (whitespace.Location.StartPoint.IndexOnLine == 0 && Regex.IsMatch(whitespace.Text, "^ +"))
          {
            this.AddViolation(whitespace.FindParentElement(), whitespace.LineNumber, "TabsMustBeUsed");
          }
        }
    
        private void CheckTabsInComment(CsToken comment)
        {
          Param.AssertNotNull(comment, "comment");
    
          var lines = comment.Text.Split('\n');
          for (int i = 0; i < lines.Length; i++)
          {
            if (Regex.IsMatch(lines[i], "^ +"))
            {
              this.AddViolation(comment.FindParentElement(), comment.LineNumber + i, "TabsMustBeUsed");
            }
          }
        }
      }
    }
