        public void Programm( ProjektClass p0, TIAClass p1, Action<string> log )
        {
			Task.Run(() =>
			{
				// do something
				log.Invoke("here am I!");
				// do something else
				log.Invoke("here am I again!");
				// do something more
			});
        }
		
