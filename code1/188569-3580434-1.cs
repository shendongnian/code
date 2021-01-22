    <html xmlns="http://www.w3.org/1999/xhtml">
    	<body>
    		<h1>Validation Fail</h1>
    		<h2>Books with no float price</h2>
    		<ul>
    			<li>&lt;Book&gt;&lt;ID&gt;1&lt;/ID&gt;&lt;Name&gt;Book1&lt;/Name&gt;&lt;Price&gt;24.??&lt;/Price&gt;&lt;Country&gt;US&lt;/Country&gt;&lt;/Book&gt;</li>
    		</ul>
    		<h2>Books with empty elements</h2>
    		<ul>
    			<li>&lt;Book&gt;&lt;ID&gt;1&lt;/ID&gt;&lt;Name&gt;&lt;/Name&gt;&lt;Price&gt;24.69&lt;/Price&gt;&lt;/Book&gt;</li>
    		</ul>
    		<h2>Books missing elements</h2>
    		<ul>
    			<li>&lt;Book&gt;&lt;ID&gt;1&lt;/ID&gt;&lt;Name&gt;&lt;/Name&gt;&lt;Price&gt;24.69&lt;/Price&gt;&lt;/Book&gt;</li>
    		</ul>
    		<h2>Books with no unique ID</h2>
    		<ul>
    			<li>&lt;Book&gt;&lt;ID&gt;1&lt;/ID&gt;&lt;Name&gt;Book1&lt;/Name&gt;&lt;Price&gt;24.??&lt;/Price&gt;&lt;Country&gt;US&lt;/Country&gt;&lt;/Book&gt;</li>
    			<li>&lt;Book&gt;&lt;ID&gt;1&lt;/ID&gt;&lt;Name&gt;&lt;/Name&gt;&lt;Price&gt;24.69&lt;/Price&gt;&lt;/Book&gt;</li>
    		</ul>
    	</body>
    </html>
