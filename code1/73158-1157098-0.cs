    <?xml version="1.0" encoding="utf-8" ?>
    <CodeSnippets  xmlns="http://schemas.microsoft.com/VisualStudio/2005/CodeSnippet">
      <CodeSnippet Format="1.0.0">
        <Header>
          <Title>Generic event with two types/arguments.</Title>
          <Shortcut>ev2Generic</Shortcut>
          <Description>Code snippet for event handler and On method</Description>
          <Author>Kyralessa</Author>
          <SnippetTypes>
            <SnippetType>Expansion</SnippetType>
          </SnippetTypes>
        </Header>
        <Snippet>
          <Declarations>
            <Literal>
              <ID>type1</ID>
              <ToolTip>Type of the first property in the EventArgs subclass.</ToolTip>
              <Default>propertyType1</Default>
            </Literal>
            <Literal>
              <ID>arg1Name</ID>
              <ToolTip>Name of the first argument in the EventArgs subclass constructor.</ToolTip>
              <Default>property1Name</Default>
            </Literal>
            <Literal>
              <ID>property1Name</ID>
              <ToolTip>Name of the first property in the EventArgs subclass.</ToolTip>
              <Default>Property1Name</Default>
            </Literal>
            <Literal>
              <ID>type2</ID>
              <ToolTip>Type of the second property in the EventArgs subclass.</ToolTip>
              <Default>propertyType2</Default>
            </Literal>
            <Literal>
              <ID>arg2Name</ID>
              <ToolTip>Name of the second argument in the EventArgs subclass constructor.</ToolTip>
              <Default>property2Name</Default>
            </Literal>
            <Literal>
              <ID>property2Name</ID>
              <ToolTip>Name of the second property in the EventArgs subclass.</ToolTip>
              <Default>Property2Name</Default>
            </Literal>
            <Literal>
              <ID>eventName</ID>
              <ToolTip>Name of the event</ToolTip>
              <Default>NameOfEvent</Default>
            </Literal>
          </Declarations>
          <Code Language="CSharp">
            <![CDATA[public class $eventName$EventArgs : System.EventArgs
          {
            public $eventName$EventArgs($type1$ $arg1Name$, $type2$ $arg2Name$)
            {
              this.$property1Name$ = $arg1Name$;
              this.$property2Name$ = $arg2Name$;
            }
            
            public $type1$ $property1Name$ { get; private set; }
            public $type2$ $property2Name$ { get; private set; }
          }
          
          public event EventHandler<$eventName$EventArgs> $eventName$;
                protected virtual void On$eventName$($eventName$EventArgs e)
                {
                    var handler = $eventName$;
                    if (handler != null)
                        handler(this, e);
                }]]>
          </Code>
        </Snippet>
      </CodeSnippet>
    </CodeSnippets>
