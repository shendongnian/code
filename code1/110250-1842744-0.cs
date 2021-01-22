    SELECT DISTINCT
         T.TransactionID,
         T.ItemID,
         T.Code,
         T.EffectiveDate,
         T.CreateDate
    FROM
         My_Table T
    INNER JOIN (
         SELECT
              T1.TransactionID,
              T2.TransactionID,
              T3.TransactionID
         FROM
              My_Table T1
         INNER JOIN My_Table T2 ON
              T2.ItemID = T1.ItemID AND
              T2.Code = 61 AND
              T2.EffectiveDate > T1.EffectiveDate
         INNER JOIN My_Table T3 ON
              T3.ItemID = T1.ItemID AND
              T3.Code = 9 AND
              T3.EffectiveDate > T2.EffectiveDate
         WHERE
              T1.Code = 51
         ) SQ ON
         SQ.TransactionID = T1.TransactionID OR
         SQ.TransactionID = T2.TransactionID OR
         SQ.TransactionID = T3.TransactionID
