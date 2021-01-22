		public bool Add (string path)
		{
			using(SvnClient client = NewSvnClient()){
				SvnAddArgs args = new SvnAddArgs();
				args.Depth = SvnDepth.Empty;
				args.AddParents = true;
				return client.Add(path, args);
			}
		}
		public bool Commit (string path, string message)
		{
			using(SvnClient client = NewSvnClient()){
				SvnCommitArgs args	= new SvnCommitArgs();
				
				args.LogMessage		= message;
				args.ThrowOnError	= true;
				args.ThrowOnCancel	= true;
				try { 
					return client.Commit(path, args);
				} catch(Exception e){
					if( e.InnerException != null ){
						throw new Exception(e.InnerException.Message, e);
					}
					throw e;
				}
			}
		}
