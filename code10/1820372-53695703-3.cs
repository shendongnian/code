    Call Method(ByVal variable)
                                  +---------+
                                  |         |
            variable +----------> | Object  |
                                  |         |
                                  +---+-----+
                                      ^
            Sub Method (ByVal p)      |
                p  +------------------+        'If you change p here, it does NOT change variable.
            End Sub
