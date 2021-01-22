        DateTime timestamp = Aws_GetDatestamp();
        string signature = Aws_GetSignature( "PutObject", timestamp );
        byte[] data = UnicodeEncoding.ASCII.GetBytes( content );
        service.PutObjectInline( "MainBucket", cAWSSecretKey, metadata,
                data, content.Length, null,
                StorageClass.STANDARD, true,
                cAWSAccessKeyId, timestamp, true,
                signature, null );
