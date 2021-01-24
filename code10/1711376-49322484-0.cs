    customerMock
        .Setup(_ => _.GetCustomerSecret(It.IsAny<string>()))
        .Returns((string publicKey) => {
            var customer = customerList.Single(x => x.PublicKey == publicKey);
            return new[] { customer.PrivateKey, customer.HttpReferer ?? string.Empty};
        });
