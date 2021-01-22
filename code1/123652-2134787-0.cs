	<?xml version="1.0" encoding="utf-8" ?>
	<CodeSnippets  xmlns="http://schemas.microsoft.com/VisualStudio/2005/CodeSnippet">
		<CodeSnippet Format="1.0.0">
			<Header>
				<Title>Dispose pattern</Title>
				<Shortcut>dispose</Shortcut>
				<Description>Code snippet for virtual dispose pattern</Description>
				<Author>SLaks</Author>
				<SnippetTypes>
					<SnippetType>Expansion</SnippetType>
					<SnippetType>SurroundsWith</SnippetType>
				</SnippetTypes>
			</Header>
			<Snippet>
				<Declarations>
					<Literal Editable="false">
						<ID>classname</ID>
						<ToolTip>Class name</ToolTip>
						<Default>ClassNamePlaceholder</Default>
						<Function>ClassName()</Function>
					</Literal>
				</Declarations>
				<Code Language="csharp">
					<![CDATA[
			///<summary>Releases unmanaged resources and performs other cleanup operations before the $classname$ is reclaimed by garbage collection.</summary>
			~$classname$() { Dispose(false); }
			///<summary>Releases all resources used by the $classname$.</summary>
			public void Dispose() { Dispose(true); GC.SuppressFinalize(this); }
			///<summary>Releases the unmanaged resources used by the $classname$ and optionally releases the managed resources.</summary>
			///<param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
			protected virtual void Dispose(bool disposing) {
				if (disposing) {
					$end$$selected$
				}
			}]]>
				</Code>
			</Snippet>
		</CodeSnippet>
	</CodeSnippets>
