	private void button2_Click(object sender, EventArgs e)
	{
		String srvName = "xxxxxxxxxxxxx";
		String dbName = "yyyyy";
		Server srv = new Server(new ServerConnection() { ServerInstance = srvName });
		Database db = srv.Databases[dbName];
		DependencyWalker dependencyWalker = new DependencyWalker(srv);
		DependencyTree dependencyTree = dependencyWalker.DiscoverDependencies(
			new Urn[] { db.StoredProcedures["test", "dbo"].Urn }, DependencyType.Parents);
		var dep = new DependencyPrinter(dependencyTree);
		treeView1.Nodes.Clear();
		dep.PrintDependency2(treeView1);
		treeView1.ExpandAll();
	}
