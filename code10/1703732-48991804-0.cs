    foreach (typeParam in new []{ typeof(bool), typeof(DateTime) })
        try {
            var typeObj = Activator.CreateInstance(type);
            var method =     typeof(IActorStateManager).GetMethod(nameof(IActorStateManager.GetStateAsync));
            var generic = method.MakeGenericMethod(typeParam);
            dynamic task = generic.Invoke(typeObj, new[] { stateName })
            object result = await task;
            return DoSomething(result);
        }
        catch() {
            continue;
        }
    }
