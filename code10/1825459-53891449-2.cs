    if (randomStepNumber == 0)                
    {    
        GameObject validGameObject = null;
        while(validGameObject == null)
        {
            validGameObject = snakeGameObjectFactory.Generate();
            foreach(var snake in snakeElements)
            {
                if (validGameObject.XPosition == snake.XPosition &&
                    validGameObject.YPosition == snake.YPosition)
                {
                    validGameObject = null;
                    break;
                }
            }
            if (validGameObject != null)
            {
                foreach(var gameObject in gameObjects)
                {
                    if (validGameObject.XPosition == gameObject.XPosition &&
                        validGameObject.YPosition == gameObject.YPosition)
                    {
                        validGameObject = null;
                        break;
                    }
                }
            }
        }
        gameObjects.Add(validGameObject);
        randomStepNumber = random.Next(10, 30);
    }
