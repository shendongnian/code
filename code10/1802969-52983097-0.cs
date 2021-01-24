    class ComputerPlayer
    {
        char[,] charMap;
        int rows, cols;
        Hashtable visitedFields = new Hashtable();
        Queue<Point> queue = new Queue<Point>();
        Stack<Point> wayback = new Stack<Point>();
        Form1 world;
        public ComputerPlayer(Form1 world, char[,] charMap, int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            this.charMap = charMap;
            this.world = world;
        }
         
        public void StartBFS()
        {
            Timer t1 = new Timer();
                t1.Interval = 1000;
                t1.Tick += new EventHandler(T1_Tick);
            t1.Start();
            Console.WriteLine("started");
        }
        private void T1_Tick(object sender, EventArgs e)
        {
            Console.WriteLine("tick");
            SearchItem(new Point(GetPlayerPosCol(), GetPlayerPosRow()), new Point(GetPlayerPosCol(), GetPlayerPosRow()));
            Console.WriteLine(queue.Count);
            while(queue.Count > 0)
            {
                Point pointer = queue.Dequeue();
                if(charMap[pointer.X,pointer.Y] == '.')
                {
                    Point coor = pointer;
                    do
                    {
                        wayback.Push(coor);
                        coor = (Point)visitedFields[coor];
                    }
                    while (!visitedFields[coor].Equals(coor));
                    while(wayback.Count > 0)
                    {
                        Point way = wayback.Pop();
                        if(way.X > GetPlayerPosCol())
                        {
                            world.MovePlayer(Form1.Direction.RIGHT);
                        }
                        if (way.X < GetPlayerPosCol())
                        {
                            world.MovePlayer(Form1.Direction.LEFT);
                        }
                        if (way.Y > GetPlayerPosRow())
                        {
                            world.MovePlayer(Form1.Direction.DOWN);
                        }
                        if (way.Y > GetPlayerPosRow())
                        {
                            world.MovePlayer(Form1.Direction.UP);
                        }
                    }
                    world.UptdateMap();
                }
            }
            visitedFields.Clear();
            queue.Clear();
            wayback.Clear();
        }
        private Point SearchItem(Point coor, Point coorFrom)
        {
            
            try
            {
                visitedFields.Add(coor, coorFrom);
                Console.WriteLine("found field");
                queue.Enqueue(coor);
                if (charMap[coor.X + 1, coor.Y] != '#')
                {
                    return SearchItem(new Point(coor.X + 1, coor.Y), coor);
                }
                if (charMap[coor.X - 1, coor.Y] != '#')
                {
                    return SearchItem(new Point(coor.X - 1, coor.Y), coor);
                }
                if (charMap[coor.X, coor.Y + 1] != '#')
                {
                    return SearchItem(new Point(coor.X, coor.Y + 1), coor);
                }
                if (charMap[coor.X, coor.Y - 1] != '#')
                {
                    return SearchItem(new Point(coor.X, coor.Y - 1), coor);
                }
            }
            catch
            {
                
            }
            return new Point(-1, -1);
        }
        private int GetPlayerPosCol()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    switch (charMap[j, i])
                    {
                        case '@':
                            return j;
                            break;
                        default:
                            break;
                    }
                }
            }
            return 0;
        }
        private int GetPlayerPosRow()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    switch (charMap[j, i])
                    {
                        case '@':
                            return i;
                            break;
                        default:
                            break;
                    }
                }
            }
            return 0;
        }
        public void SetCharMap(char[,] charMap)
        {
            this.charMap = charMap;
        }
    }
