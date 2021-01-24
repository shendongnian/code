    var repositoryMock = new Mock<IDbRepository>();
    repositoryMock
        .Setup(repository => repository.GetDataAsync(It.IsAny<Func<Status, bool>>()))
        .ReturnsAsync((Func<Status, bool> filter) => {//<-- grab passed argument here
            if (filter == null)
                return statusList.FirstOrDefault();
            return statusList.FirstOrDefault(filter);
        });
