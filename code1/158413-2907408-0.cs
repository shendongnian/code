    PostVoteTypeFunctions myVar = PostVoteTypeFunctions.UpVote;
    public static struct PostVoteTypeFunctions 
    { 
        private int id;
        private bool isDef;
        private PostVoteTypeFunctions ( )  { }
        private PostVoteTypeFunctions(int value) { id=value; idDef = true; }
    
        public bool HasValue { get { return isDef; } }
        public bool isNull{ get { return !isDef; } }
        public string Name 
        { 
           get 
           {  return 
                 id==1? "UpVote":
                 id==2? "DownVote":
                 id==3? "SelectAnswer":
                 id==4? "Favorite":
                 id==5? "Offensive":
                 id==6? "Spam": "UnSpecified";
           }
        }
        public int PointValue 
        { 
           get 
           {  return // Why not hard code these values here as well  ?
                 id==1? PostVotePointValue.UpVote:
                 id==2? PostVotePointValue.DownVote
                 id==3? PostVotePointValue.SelectAnswer:
                 id==4? PostVotePointValue.Favorite:
                 id==5? PostVotePointValue.Offensive:
                 id==6? PostVotePointValue.Spam: 
                        0;
           }
        }
      
        public static PostVoteTypeFunctions UpVote = new PostVoteTypeFunctions(1);
        public static PostVoteTypeFunctions DownVote= new PostVoteTypeFunctions(2);
        public static PostVoteTypeFunctions SelectAnswer= new PostVoteTypeFunctions(3);
        public static PostVoteTypeFunctions Favorite= new PostVoteTypeFunctions(4);
        public static PostVoteTypeFunctions Offensive= new PostVoteTypeFunctions(5);
        public static PostVoteTypeFunctions Spam= new PostVoteTypeFunctions(0);       
    } 
