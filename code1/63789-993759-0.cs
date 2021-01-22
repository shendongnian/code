    mockRequestRepository.Setup(repo => repo.GetAll(It.IsAny<int>()))
        .Returns(new List<Request> {
            new Request { Prop1 = ..., PropN = ... },
            new Request { Prop1 = ..., PropN = ... },
            ...
        });
