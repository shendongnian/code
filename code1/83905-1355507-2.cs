    Public Class Map
        Public ReadOnly Property Behavior As MapBehavior
        
        Public Sub SetBehavior(behavior)
        Public Sub Start()
    End Class
    
    Public MustInherit Class MapBehavior
        Public MustOverride Sub Start()
    End Class
    
    Public Class PlayerSpawnBehavior
        Public Property EnemiesPerSpawn As Integer
        Public Property MaximumNumberOfEnemies As Integer
        Public ReadOnly Property NumberOfEnemies As Integer
        
        Public Sub SpawnEnemy()
        Public Sub Start()
    End Class
