    <CodeSnippet Format="1.0.0">
    <Header>
      <Title>Canonic</Title>
      <SnippetTypes>
        <SnippetType>Expansion</SnippetType>
      </SnippetTypes>
    </Header>
    <Snippet>
      <Declarations>
        <Literal>
          <ID>ClassName</ID>
          <ToolTip>Replace with the name of the class.</ToolTip>
          <Default>ClassName</Default>
        </Literal>
        <Literal>
          <ID>MethodName</ID>
          <ToolTip>Replace with the name of the method.</ToolTip>
          <Default>MethodName</Default>
        </Literal>
        <Literal>
          <ID>FirstArgName</ID>
          <ToolTip>Replace with the name of the first argument.</ToolTip>
          <Default>FirstArgName</Default>
        </Literal>
        <Literal>
          <ID>SecondArgName</ID>
          <ToolTip>Replace with the name of the second argument.</ToolTip>
          <Default>SecondArgName</Default>
        </Literal>
        <Literal>
          <ID>ResultName</ID>
          <ToolTip>Replace with the name of the result.</ToolTip>
          <Default>ResultName</Default>
        </Literal>
      </Declarations>
      <Code Language="CSharp">
        <![CDATA[            Logger.LogMethod("$FirstArgName$", $FirstArgName$,"$SecondArgName$", $SecondArgName$);
            try
            {
                Validator.Verify($FirstArgName$, $SecondArgName$);
                //VerifyFields();
                Logger.LogReturn($ResultName$);
                return $ResultName$;
            }
            #region Exception
            catch (Exception exp)
            {
                Logger.LogException("$ClassName$.$MethodName$", exp);
                throw;
            }
            #endregion Exception
]]>
      </Code>
    </Snippet>
