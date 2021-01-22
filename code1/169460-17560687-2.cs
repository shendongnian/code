	<Query>
		<Where>
			<And>
				<Or>
					<Leq>
						<FieldRef Name='PublishingStartDate'/>
						<Value Type='DateTime' IncludeTimeValue='TRUE'>
							<Today/>
						</Value>
					</Leq>
					<IsNull>
						<FieldRef Name='PublishingStartDate'/>
					</IsNull>
				</Or>
				<Or>
					<Geq>
						<FieldRef Name='PublishingExpirationDate'/>
						<Value Type='DateTime' IncludeTimeValue='TRUE'>
							<Today/>
						</Value>
					</Geq>
					<IsNull>
						<FieldRef Name='PublishingExpirationDate'/>
					</IsNull>
				</Or>
			</And>
		</Where>
	</Query>
 
