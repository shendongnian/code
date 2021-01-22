    const double CollisionBudget = 0.005;
    Collision[] _allPossibleCollisions;
    int _lastCheckedCollision;
    void HandleCollisions() {
        var startTime = HighPerformanceCounter.Now;
        if (_allPossibleCollisions == null || 
            _lastCheckedCollision >= _allPossibleCollisions.Length) {
            // Start a new series
            _allPossibleCollisions = GenerateAllPossibleCollisions();
            _lastCheckedCollision = 0;
        }
        for (var i=_lastCheckedCollision; i<_allPossibleCollisions.Length; i++) {
            // Don't go over the budget
            if (HighPerformanceCount.Now - startTime > CollisionBudget) {
                break;
            }
            _lastCheckedCollision = i;
            if (CheckCollision(_allPossibleCollisions[i])) {
                HandleCollision(_allPossibleCollisions[i]);
            }
        }
    }
