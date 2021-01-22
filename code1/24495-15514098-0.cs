    <CodeSnippets xmlns="http://schemas.microsoft.com/VisualStudio/2005/CodeSnippet">
        <CodeSnippet Format="1.0.0">
            <Header>
                <Title>Singleton Class</Title>
                <Author>TWSoft</Author>
                <Description>Generates a singleton class</Description>
                <SnippetTypes>
                    <SnippetType>Expansion</SnippetType>
                </SnippetTypes>
                <Keywords>
                    <Keyword>Singleton</Keyword>
                </Keywords>
                <Shortcut>singleton</Shortcut>
            </Header>
            <Snippet>
                <Declarations>
                    <Literal>
                        <ID>ClassName</ID>
                        <ToolTip>Replace with class name</ToolTip>
                        <Default>MySingletonClass</Default>
                    </Literal>
                </Declarations>
        
                <Code Language="CSharp">
                    <![CDATA[
                    public class $ClassName$
                    {
                        #region Singleton
                        static readonly $ClassName$ mInstance = new $ClassName$();
              
                        // Explicit static constructor to tell C# compiler
                        // not to mark type as beforefieldinit
                        static $ClassName$()
                        {
                        }
                        private $ClassName$()
                        {
                        }
                        public static $ClassName$ Instance
                        {
                            get { return mInstance; }
                        }
                    #endregion
                    }
                    ]]>
                </Code>
            </Snippet>
        </CodeSnippet>
    </CodeSnippets>
