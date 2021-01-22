    <?xml version="1.0" encoding="utf-8" ?>
    <CodeSnippets  xmlns="http://schemas.microsoft.com/VisualStudio/2005/CodeSnippet">
    	<CodeSnippet Format="1.0.0">
    		<Header>
    			<Title>Generic event with one type/argument.</Title>
    			<Shortcut>ev1Generic</Shortcut>
    			<Description>Code snippet for event handler and On method</Description>
    			<Author>Ryan Lundy</Author>
    			<SnippetTypes>
    				<SnippetType>Expansion</SnippetType>
    			</SnippetTypes>
    		</Header>
    		<Snippet>
    			<Declarations>
            <Literal>
              <ID>type</ID>
              <ToolTip>Type of the property in the EventArgs subclass.</ToolTip>
              <Default>propertyType</Default>
            </Literal>
            <Literal>
              <ID>argName</ID>
              <ToolTip>Name of the argument in the EventArgs subclass constructor.</ToolTip>
              <Default>propertyName</Default>
            </Literal>
            <Literal>
              <ID>propertyName</ID>
              <ToolTip>Name of the property in the EventArgs subclass.</ToolTip>
              <Default>PropertyName</Default>
            </Literal>
            <Literal>
              <ID>eventName</ID>
              <ToolTip>Name of the event</ToolTip>
              <Default>NameOfEvent</Default>
            </Literal>
    			</Declarations>
          <Code Language="CSharp"><![CDATA[public class $eventName$EventArgs : System.EventArgs
          {
            public $eventName$EventArgs($type$ $argName$)
            {
              this.$propertyName$ = $argName$;
            }
            
            public $type$ $propertyName$ { get; private set; }
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
