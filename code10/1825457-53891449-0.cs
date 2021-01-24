    if (randomStepNumber == 0)                
    {    
        GameObject validGameObject;
        do
        {
            validGameObject = snakeGameObjectFactory.Generate();
        }
        while(snakeElements.Any(s => validGameObject.XPosition == s.XPosition && validGameObject.YPosition == s.YPosition) ||
             gameObjects.Any(o => validGameObject.XPosition == o.XPosition && validGameObject.YPosition == o.YPosition));
        gameObjects.Add(validGameObject);
        randomStepNumber = random.Next(10, 30);
    }
