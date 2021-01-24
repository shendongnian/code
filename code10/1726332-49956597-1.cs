        void Update()
        {
            // ...
            var objs = new GameObjectParams3(enemy1, enemy2, enemy3);
            // Or:
            //
            // var objs = new GameObjectParams3();
            // objs.Object0 = GameObject.Find("Player1");
            // Better, make ObjectN private and:
            //
            // var objs = new GameObjectParams3();
            // objs.Push( GameObject.Find("Player1") );
            //
            // To have .Length afterwards.
            Vector3 newPos = new Vector3(0, 0, 0);
            moveObjects(newPos, 3f, objs);
        }
        void moveObjects(Vector3 newPos, float duration, GameObjectParams3 objs)
        {
            while (true)
            {
                var obj = objs.Next();
                if (obj == null)
                    return;
                //StartCoroutine(moveToNewPos(objs[i].transform, newPos, duration));
            }
            /*
            var len = objs.Length;
            for (int n = 0; n < len; n++)
            {
                var obj = objs.Next();
                StartCoroutine(moveToNewPos(objs[i].transform, newPos, duration));
            }
            */
        }
