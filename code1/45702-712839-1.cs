    using( System.IO.FileStream writeStream = new System.IO.FileStream( fileName, System.IO.FileMode.OpenOrCreate ) ) {
        using( System.IO.BinaryWriter writer = new System.IO.BinaryWriter( writeStream ) ) {
            //do stmth
        }
    }
