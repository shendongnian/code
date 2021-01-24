        protected List<KeyCode> Directions = new List<KeyCode>();
        protected void Update()
        {
            var hasDirection = TrackKey(KeyCode.UpArrow) || TrackKey(KeyCode.DownArrow) || TrackKey(KeyCode.LeftArrow) || TrackKey(KeyCode.RightArrow);
            if (!hasDirection)
            {
                Directions.Clear();
                return;
            }
            // Has a direction.  Check "Last" item in list (top of stack) and proceed.
            Quaternion rotation = Quaternion.identity;
            switch (Directions[Directions.Count -1])
            {
                case KeyCode.UpArrow: // Set Rotation Here
                    break;
                case KeyCode.DownArrow: // Set Rotation Here
                    break;
                case KeyCode.LeftArrow: // Set Rotation Here
                    break;
                case KeyCode.RightArrow: // Set Rotation Here
                    break;
            }
            // Instantiate fireball using rotation from above
            Instantiate(prefab, position, rotation);
        }
        protected bool TrackKey(KeyCode key)
        {
            // if key was released, remove each item where the item equals key
            if (Input.GetKeyUp(key)) Directions.RemoveAll(item => item == key);
            // Always adds to end, virtual 'Stack'
            if (Input.GetKeyDown(key)) Directions.Add(key);
            return Input.GetKey(key);
        }
