    private bool onTheRun = false;
    void regenDestination() {
        randomDestination = new Vector2(Random.Range(-11, 11), Random.Range(-5, 5));
    }
    void runAway() {
        if (!isDead) {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, -movementSpeed * 1.5f * Time.deltaTime);
            onTheRun = true;
        }
    }
    void runToRandomLocation() {
        if (!isDead) {
            if (Vector2.Distance(transform.position, player.transform.position) > 3)    // if player is not near
            {
                if (onTheRun)
                {
                    regenDestination();
                    onTheRun = false;
                }
                if (Vector2.Distance(transform.position, randomDestination) <= 2)   // when NPC is close to destination he sets another
                {
                    regenDestination();
                } else {
                    transform.position = Vector2.MoveTowards(transform.position, randomDestination, movementSpeed * Time.deltaTime);   // NPC is just walking from point to point
                }
            } else {
                runAway();  // if player is near
            }
        }
    }
