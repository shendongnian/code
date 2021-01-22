    void treeView(string [] LineString)
		{
			int line = LineString.Length;
			string AssmMark = "";
			string PartMark = "";
			TreeNode aNode;
			TreeNode pNode;
			for ( int i=0 ; i<line ; i++){
				string sLine = LineString[i];
				if ( sLine.StartsWith("ASSEMBLY:") ){
					sLine  = sLine.Replace("ASSEMBLY:","");
					string[] aData = sLine.Split(new char[] {','});
					AssmMark  = aData[0].Trim();
					//TreeNode aNode;
					//aNode = new TreeNode(AssmMark);
					treeView1.Nodes.Add(AssmMark,AssmMark);
				}
				if( sLine.Trim().StartsWith("PART:") ){
					sLine  = sLine.Replace("PART:","");
					string[] pData = sLine.Split(new char[] {','});
					PartMark = pData[0].Trim();
					pNode = new TreeNode(PartMark);
					treeView1.Nodes[AssmMark].Nodes.Add(pNode);
				}
			}
