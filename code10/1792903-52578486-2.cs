    // Update is called once per frame
    void Update () {
        if (human != null)
        {
            Vector3 targetPosition = human.Target.GameObject.transform.position;
            if (transform.position.Equals(targetPosition)) {
                if (!human.HasAHouse)
                    ((House)human.Target).AddHuman(human);
            }
            else {
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
            }
        }
    }
