    UPDATE T1
    SET T1.Column1 = T2.Column1
    	,T1.Column2 = T2.Column2
    	,T1.Column3 = T2.Column3
    	,T1.Column4 = T2.Column4
    FROM Table1 T1
    INNER JOIN Table2 T2
    	ON T1.Table1PrimaryKey = T2.Table2PrimaryKey
    WHERE T1.Column1 <> T2.Column1
    	OR T1.Column2 <> T2.Column2
        OR T1.Column3 <> T2.Column3
        OR T1.Column4 <> T2.Column4
