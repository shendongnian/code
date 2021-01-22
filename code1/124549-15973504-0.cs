      MyDomainService_Context = new MyDomainService();
      EntityQuery<MyEntity > mQuery = null;
      mQuery = from q in _Context.GetMyDomainServiceQuery()
               select q;
      LoadOperation<MyEntity > loadOpLoadEntities = _Context.Load(mQuery, LoadOpLoadEntitiesCallBack, null);
    }
    
