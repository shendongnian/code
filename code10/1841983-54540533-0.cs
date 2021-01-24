    void OnEnable()
    {
        for(var i= 0; i < InteractiveObjects.Length; i++)
        {
            var index = i;
            InteractiveObjects[index].OnOver += () => {
                foreach (MeshRenderer renderer in InteractiveObjects[index].GetComponentsInChildren<MeshRenderer>())
                {
                    renderer.enabled = true;
                }
    
                foreach (SpriteRenderer renderer in InteractiveObjects[index].GetComponentsInChildren<SpriteRenderer>())
                {
                    renderer.enabled = true;
                }
    
                InteractiveObjects[index].OnOut += () => {
                    foreach (MeshRenderer renderer in InteractiveObjects[index].GetComponentsInChildren<MeshRenderer>())
                    {
                        renderer.enabled = false;
                    }
    
                    foreach (SpriteRenderer renderer in InteractiveObjects[index].GetComponentsInChildren<SpriteRenderer>())
                    {
                        renderer.enabled = false;
                    }
                };
            };
        }
    }
