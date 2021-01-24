	var privateKeyAttributes = new List<ObjectAttribute>()
	{
		new ObjectAttribute(CKA.CKA_CLASS, CKO.CKO_PRIVATE_KEY),
		new ObjectAttribute(CKA.CKA_TOKEN, true),
		new ObjectAttribute(CKA.CKA_PRIVATE, true),
		new ObjectAttribute(CKA.CKA_MODIFIABLE, true),
		new ObjectAttribute(CKA.CKA_LABEL, ...),
		new ObjectAttribute(CKA.CKA_ID, ...),
		new ObjectAttribute(CKA.CKA_KEY_TYPE, CKK.CKK_RSA),
		new ObjectAttribute(CKA.CKA_MODULUS, rsaPrivKeyParams.Modulus.ToByteArrayUnsigned()),
		new ObjectAttribute(CKA.CKA_PUBLIC_EXPONENT, rsaPrivKeyParams.PublicExponent.ToByteArrayUnsigned()),
		new ObjectAttribute(CKA.CKA_PRIVATE_EXPONENT, rsaPrivKeyParams.Exponent.ToByteArrayUnsigned()),
		new ObjectAttribute(CKA.CKA_PRIME_1, rsaPrivKeyParams.P.ToByteArrayUnsigned()),
		new ObjectAttribute(CKA.CKA_PRIME_2, rsaPrivKeyParams.Q.ToByteArrayUnsigned()),
		new ObjectAttribute(CKA.CKA_EXPONENT_1, rsaPrivKeyParams.DP.ToByteArrayUnsigned()),
		new ObjectAttribute(CKA.CKA_EXPONENT_2, rsaPrivKeyParams.DQ.ToByteArrayUnsigned()),
		new ObjectAttribute(CKA.CKA_COEFFICIENT, rsaPrivKeyParams.QInv.ToByteArrayUnsigned())
	};
